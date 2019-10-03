# Kata10: Hashes vs. Classes

My thoughts on http://codekata.com/kata/kata10-hashes-vs-classes/

If we’re programming business applications in a language such as Java or C#, we’re used to constructing and using classes to manipulate our business objects. Is this always the right way to go, or would a less formal approach serves us well sometimes?

This week’s topic doesn’t involve a coding challenge. Instead, we’re thinking about design and tradeoffs.

Imagine that you’ve been asked to write an export utility for a large and complex database. The export has to read data from 30 or so tables (perhaps 100 columns are potentially written to each export record). Some of the exported data is written exactly as read from the database, but other exported data must be calculated. In addition, if certain flag fields have specific values, then additional data must be read from the database to complete an export row.

The export data must obviously be correct, but the client is also asking for a flexible solution; their world changes a lot.

One solution is to use existing business objects and existing persistence mechanisms, and to use higher-level classes to aggregate their results into a form that can be used to generate export rows. This higher level object could perform the calculations necessary for the virtual fields, and read in additional business objects if the flag fields dictate.

An alternative solution might be to read the data row at a time into a Hash (an associative array, dictionary, …) using ad-hoc queries, keying the hash on the field names. A separate pass could then be made to perform any necessary calculations, storing the results back in to the same hash. Additional data could be read from the database if the flag fields are set, again storing the results in the hash. The contents of the hash are then used to write the export record, and we loop back to do the next row.

This kata is a thought experiment. What are the top three advantages and top three disadvantages of the two approaches? If you’re been using classes to hold data in your business applications, what would the impact be if you were to switch to hashes, and vice versa? Is this issue related to the static/dynamic typing debate?

# Notes
1. hashes - you can pass through any properies you don't have special handling for.
    1. if you want to omit some properties, you just filter them out
    2. if you have special handling for some properties you can specify just it
2. hashes - useful if you have business objects with a lot of properies and you don't want to specify all of them, they can change, and you just want to pass the through when they change
   * then again when you code the "special processing"/"handling" ussing regular classes it's easier to avoid typos etc.
     * I sometimes use dynamic classes, but if I pass those dynamic object to too many places and use too many properies of them I get lost, and introduce a type for them.
       * by introducing properies you can not easily loop throught them
         * you can in C# using reflection
           * why not use hash object in the first place when you want to loop throught your properies?
             * I think this could loop for ever
3. hashes - brings to attentions that business objects and just objects composed of some meta-data
   * then again if you comfortable with this kind of thinking, it does not matter if you use classes with fileds or hashes
The pros/cons here remind me of the thought debat I have when considering creating a type or a tuple.
  * I don't like to return tuples from my methods since I tend to forget what the tuple contains
  * but if I'm the creator and only user of the tuple it is fine since the creation and usage and not too far away.
  * but I remember reading my own code using dynamic object aka. tuples after few months - I regreted that I didn't introduce types with named properties

I'm not 100% sure about this but sometimes I get the feeling that when we start some new project and a class is modified from all sides it's more useful to use a dynamic type. But after sometimes things settle down and a class with properies might be better so new comers don't have to read all the code to find out what that object actually holds.

I remember this debat in my mind at work. We use a queueing/messaging system - RabbitMQ. A particular type of message is exchanged by all services.
During hot development there were a lot of changes to this class, so I was thinking about making it a dyamic thing. And it was for some time.
But it had it's draw back, we were making typos, could not agree on some formats. After some time I tried to do a library with this message shared by all system, I made it typesafe and it worked well. You don't have to look up the documentaiton on properies the class holds, you just can use intellisense (since it was VisualStudio and C#).

Then again I remember when downloading some data from the internet. The rows had 28 columns. Ofc I could introduce a class, but I was only interested in downloading the data, chaniging the date format and passing the data further, a hash thing seems here like a good fit.

I also remember working on a CMS (Content Managment System). It's like sharepoint or google drive for the company I was working for.
A document had it's content and a lot of meta-data. The meta-data aka. attributes were dynamic - you could change available properties on a document in runtime (happend rarely or never).
It was how the system was designed by the vendor. I remember that we initially started with totally dyanimc stuff since this was how the API was defined. Then moved to classes with properites representing attributes. The class hierarchy grew bigger. I recall it didn't work too well.
We ended up with a "sort of dynamic" `attribute bag` object which was storing attributes as key/values pairs. There were some predefined, frequently used keys, but you were free to use any string as a key. I recall this worked quite well.

To sumup - from my POV it depends on the usecase and your preferences.
