EXTERNAL startQuest(treeTalks)

So, you found my die?
Thank you hoomin. The big ol' tree said that you would never make it, but here you are.
...
        +[No worries!]
        -> dontWorry
        +[So, how exactly can i escape this hellscape?]
        -> helpMeEscape
        +[...]
        -> goodbye
        
=== dontWorry ===
Alright hoomin.
I think I'm gonna take my leave now.
Godbye.
...
        +[Good riddance!]
        -> goodbye
        +[You wanted to help me escape?]
        -> helpMeEscape
        +[...]
        -> goodbye
        
=== helpMeEscape ===
Oh, hehe, yeah right.
So, hoomin, just listen now:
You just have to spread your wings and fly!
...
        +[I don't have wings.]
        -> wellGoodbye
        +[That's your help?]
        -> wellGoodbye
        +[...]
        -> goodbye
        
=== goodbye ===
[And with these last words, you see the pigeon flying away into the clouds. 
You are alone again, surrounded by salty water and with a bunch of trees to look at.
And one of them looks different than the last time.]
~ startQuest ("the Tree talks")
-> DONE

=== wellGoodbye ===
Well, too bad.
-> goodbye