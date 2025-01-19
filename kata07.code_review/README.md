My attempt on http://codekata.com/kata/kata07-howd-i-do/
Reviewing: https://github.com/inwenis/bakeChart

## Good things:

+ 10 * 60 * 1000 -> makes it easy to see it's 10 min

+ private static string _rootOutputDirectory = "C:/bakeChartData"; -> good naming, I know this app outpus something and all will be in this dir

+             var result = Download();
            return Parse(result); -> good separation, it's clear what download is and what parse is

+
var xPathToAreaName = "//*[@id=\"gtsms_sms-wyniki\"]/h2";
var xPathToCompetitorListItem = "//*[@id=\"gtsms_sms-wyniki\"]/ul/li"; -> good naming, it's easy to see to which elements this xpaths points too

+
    var dateTimeFromFileName = DateTimeOffset.ParseExact(
        Path.GetFileNameWithoutExtension(file),
        "yyyy-MM-ddTHH-mm-ss",
        new DateTimeFormatInfo(),
        DateTimeStyles.AssumeUniversal); -> it's clear we're parsing the datetime from file name

I'm getting the feeling that it's much easier to read code when you know what it is supposed to do.
So if you don't understand the domain/business problem it's hard to read code.

The code I'm reviewing is my old code which downloads data and prints some charts.
I know what it's supposed to do so I can guess reasons why I have added some nonobvious pieces of code.

I remember that reading code in DCC was hard becuase I didn't know the domain/business.
And I was learning about it from the code. Is this a good idea?
Is the code a good place to learn about the business and domain? I'm having the feeling it is not.
why?
It's easy to say in human readable form:
"We're trading Gas between borders. France and Germany have a gas `border point` connecting them. When we create a trade which flows gas from Germany to the `border point` we need a trade automatically created from the `border point` to France."
This requirement is preety straight forward, and you can guess why they need it.
It would be nice to know more details, but from this you can gues that we need to submit the trades to different authorities, and France and Germany are interested only in the trades going on in theirs borders.
I can imagine the code for this requirement will be quite some code + a lot of edge cases and special cases.

If you get a screwdriver and nails it's rally hard only based on those tools to figure out why exactly you were given no hammer or screws.

+ .Replace("XXXLabelsXXX", labels) -> it's clear that the text contains some placeholders with "XXXLabelsXXX" which are supposed to be replaced

+ areaName_Competitor_Points -> it'a a dic<string,dic<string,point>> -> naming makes it clear what it holds

+ this code is clear to me:
```C#
            var bestCompetitorsFromAreas = allPoints
                .GroupBy(x => x.AreaName)
                .Select(areaGroup =>
                {
                    var groupByComp = areaGroup.GroupBy(x => x.CompetitorName);
                    var bestCompetitorFromThisArea = groupByComp
                        .Select(x => new {Competitor = x.Key, MaxVotes = x.Max(y => y.Value)})
                        .OrderBy(x => x.MaxVotes)
                        .Last();
                    return bestCompetitorFromThisArea.Competitor;
                });
```
Is it clear because I still remember what it's supossed to do?
Or is it clear because it's clearly expressed?

## Bad things:

- hardcoded paths
- commented code
- inconsistent naming - underscore in name - DownloadVotes_Parse
- path should come first in this method: private static string SaveToFile(string resultParsed, string rootOutputdirecotry)
- var result = httpClient.GetStringAsync(_url).Result; - why not await async?
- inconsistent naming - var name = node.SelectNodes("./span[2]/span/span[1]/strong")[0].InnerText;
    in other palces this is named competitorName
    var count = node.SelectNodes("./span[2]/span/span[2]/text()")[0].InnerText; - this is votes
- public static string Parse(string result) - this returns a \t separated CSV but it's not stated anywhere
    you can only know it by reading the method
- Program.Main() -> timer is not disposed
    - no reference to timer
    - might be garbage collected?
    https://gist.github.com/inwenis/d8544192df76d6fe3fd4075f310119b4

- DownloadVotes.Parse()
- we are mapping nodes to lines, so maybe we should use Select() insed of foreach?
```C#
        public static string Parse(string result)
        {
            var xPathToAreaName = "//*[@id=\"gtsms_sms-wyniki\"]/h2";
            var xPathToCompetitorListItem = "//*[@id=\"gtsms_sms-wyniki\"]/ul/li";
            StringReader reader = new StringReader(result);
            var doc = new HtmlDocument();
            doc.Load(reader);

            var areaName = doc.DocumentNode.SelectNodes(xPathToAreaName)[0].InnerText;

            var lines = doc
                .DocumentNode
                .SelectNodes(xPathToCompetitorListItem)
                .Select(competitorNode =>
                {
                    var competitorName = competitorNode.SelectNodes("./span[2]/span/span[1]/strong")[0].InnerText;
                    var votes = competitorNode.SelectNodes("./span[2]/span/span[2]/text()")[0].InnerText.Trim();
                    return competitorName + "\t" + areaName + "\t" + votes;
                });

            return string.Join("\n", lines);
        }
```
- bakeChart.Charting.Program.random - poor app design, why random colors and not predifine static colors?
- bakeChart.Charting.Program.Main() - same issue with timer
- can be simplified
var timer = new Timer(new TimerCallback(RefreshChart), null, 0, 10 * 60 * 1000);
var timer = new Timer(RefreshChart, null, 0, 10 * 60 * 1000);
- bakeChart.Charting - hard to test cuz of reading data from files
- RefreshChart() - mutating dictionary insted of creating a new one
- RefreshChart long method could be separated into pieces
- RefreshChart() - hard coded magic strings
- AddMissingPoints() - what are missing points?
- this is wierd
```C#
OrderPointsByDateTime(bestOfAllDic);
  Only50PointsShallRemainForEachCompetitor(bestOfAllDic, tortowyZascianekKey);
```
usually you first filter and then order
is this case it might make sense to order and then filter since we are filtering based on indexes, but at least a comment maybe?
- poor naming - method and parameters
`private static void DoChart(Dictionary<string, List<Point>> dictionary, string tortowyZascianekKey, string outputFileName)`

- `var justSomeKey = areaNameCompetitorPoint.Value.First().Key;` - poor name
- `var dic = areaNameCompetitorPoint.Value;` - dic poor name
-                     
```C#
var fileName = areaNameCompetitorPoint.Key
                        .Substring(areaNameCompetitorPoint.Key.IndexOf("("))
                        .Replace(" ", "")
                        .Replace("(", "")
                        .Replace(")", "")
                        .Replace("/", "")
                        .Replace("-", "");
```
                        could be extracted to some ToFileName fun()
                        or RemoveIllegalfileNameCharacters
 - `@"C:\inetpub\wwwroot\" + outputFileName` should be done by Path.Join()
 - `foreach (var keyValuePair in dictionary)` - bad naming, we only have type names here

## Bugs:

1. bakeChart.Program.Main() - no reference to timer, can be garbage collected
    same for bakeChart.Charting.Program.Main()
2. accidentally pressing [enter] stops the app
3. we might run out of space on disk
4. permission issue - might be not able to write files
5. path maybe too long
6. if names of competitor change our codes breaks
7. if different areas has different datetimes our code can break since for the best.html we use datetimes from `Tortowy Zaścianek` for all other competitors
8. a lot of things with the files in which we keep data can break parsing them and the whole process fails,
    just because a single file can not be read
9. we are using a hardcoded date threshold in Charting, is this ok?