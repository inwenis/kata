# Kata10: Hashes vs. Classes

My thoughts on http://codekata.com/kata/kata10-hashes-vs-classes/

If we’re programming business applications in a language such as Java or C#, we’re used to constructing and using classes to manipulate our business objects. Is this always the right way to go, or would a less formal approach serves us well sometimes?

This week’s topic doesn’t involve a coding challenge. Instead, we’re thinking about design and tradeoffs.

Imagine that you’ve been asked to write an export utility for a large and complex database. The export has to read data from 30 or so tables (perhaps 100 columns are potentially written to each export record). Some of the exported data is written exactly as read from the database, but other exported data must be calculated. In addition, if certain flag fields have specific values, then additional data must be read from the database to complete an export row.

The export data must obviously be correct, but the client is also asking for a flexible solution; their world changes a lot.

One solution is to use existing business objects and existing persistence mechanisms, and to use higher-level classes to aggregate their results into a form that can be used to generate export rows. This higher level object could perform the calculations necessary for the virtual fields, and read in additional business objects if the flag fields dictate.

An alternative solution might be to read the data row at a time into a Hash (an associative array, dictionary, …) using ad-hoc queries, keying the hash on the field names. A separate pass could then be made to perform any necessary calculations, storing the results back in to the same hash. Additional data could be read from the database if the flag fields are set, again storing the results in the hash. The contents of the hash are then used to write the export record, and we loop back to do the next row.

This kata is a thought experiment. What are the top three advantages and top three disadvantages of the two approaches? If you’re been using classes to hold data in your business applications, what would the impact be if you were to switch to hashes, and vice versa? Is this issue related to the static/dynamic typing debate?

Notes:
1. hashes - flexible, you can pass throught any properies you don't have special handling for.
    -> if you want to omit some, you just filter them out
    -> if you have some special handling for some you specify them
    -> useful if you have business objects with a lot of properies and you don't want to specify all of them, and they can change, and you just want to pass the throught when they change
    -> then again when you code the "special processing"/handling ussing classes makes easier development since you don't have typos etc.
        I sometimes use dynamic classes, but if I pass those object to too many places and use too many properies of them I get lost, and introduce a type for them.
            -> by introducing properies you can not easily loop throught them
                -> you can in C# using reflection
                    -> why not use hash object in the first place when you want to loop throught your properies?
                        -> I think this could loop for ever
2. hashes - brings to attentions that business objects and just objects composed of some meta-data
    -> then again if you comfortable with this kind of thinking, it does not matter if you use classes with fileds or hashes
3. the pros/cons here remind me of the thought debat I have when considering creating a type or a tuple.
    -> I don't like to return tuples from my methods to others since I then forget what the tuple holds,
    -> but if I in my mthod am the creator and user of the tuple is fine since the creation and usage and not too far away.
    -> but I remember that I had read my own code using dynamic object aka. tuples and when I was reading it after few months I regreted that I didn't introduce types with named properties
I'm not 100% sure about this but sometimes I get the feeling that when we start some new project and a class is modified from all sides it's more useful to use a dynamic type. But after sometimes things settle down and a class might be better so new comers don't have to read all the code to find out what that object actually holds

I remember I had this debat in my mind at work. We use a quing/messaging system. A particular type of message is exchanged by all services.
During hot development there were a lot of changes to this class, so I was thinking about making it a dyamic thing. And it was for some time.
But it had it's draw back, we were making typos, oucnd not agree on some formats. After some time I tried to do a library with this message shared by all system, type safe and it works well. You don't have to look up the documentaiton on properies the class holds, you just can use intellisense.

Then again I was downloading some data from the net. The rows have 28 columns. Ofc I could introduce a class, but I was only interested in downloading the data, chaniging the date format and passing the data rurther, a hash thing seems here like a good thing.

I also remember working on a CMS (content managment system). It's like sharepoint or google drive for the company I was working for.
A document had it's content and a lot of meta-data. The meta-data aka. attributes were dynamic. could change during run time. They could but usually did not.
It was how the system was designed by the vendor. I remember that we initially started with totally dyanimc stuff since this was how the API was defined. Then moved to types classes holding attributes, the class hierarchy began to grow. I recall it didn't work too well.
We ended up with a "sort of dynamic" `attribute bag` object which was storing attributes as key/values pairs. There were some predefined keys frequently used, but you were free to use just a stirng. I recall this worked quite well.
