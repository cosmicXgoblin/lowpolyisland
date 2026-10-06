EXTERNAL changeDialogue(newDialogue)
EXTERNAL startQuest(questName)

So, I lost some of my precious treasure on this island and I don't know where exactly.
...
    +[And you want ME to look for it?]
        -> whyMe
    +[Too bad, have a nice day]
         ~ changeDialogue("sulking")
        -> DONE 
    +[Like, a really good piece of food?]
        -> dumbHoomin
        
=== whyMe ===
No, I am just telling you because i want to share something.
...
OF COURSE I WANT YOU TO LOOK FOR IT!
...
    +[No thank you.]
         ~ changeDialogue("sulking")
        -> DONE 
    +[Sure, I'll help you.]
        -> helpIsOnTheWay
    +[What's in it for me?]
        -> altruismIsAScam
        
=== dumbHoomin ===
Yes, why should a pigeon care about something other than food, right?
Ooooh, look at me, I'm a HOOMIN, I am categorizing things I can't understand and don't care if I am rude.
...
    +[You're the rude one. I won't help you.]
        ~ changeDialogue("sulking")
        -> DONE
    +[Sure, I'll help you.]
        -> helpIsOnTheWay
    +[What's in it for me?]
        -> altruismIsAScam
        
=== helpIsOnTheWay
In return, i can show you a way to escape this island.
...
    +[Yeah, ok.]
        -> whatIAmLookingFor
    +[No.]
        ~ changeDialogue("sulking")
        -> DONE
    +[...]
        -> whatIAmLookingFor
        
=== altruismIsAScam ===
Huh.
You can feel good aboout yourself?
And I could show you a way to escape this island.
...
    +[Yeah, ok.]
        -> whatIAmLookingFor
    +[No.]
        ~ changeDialogue("sulking")
        -> DONE
    +[...]
        -> whatIAmLookingFor
        
=== whatIAmLookingFor ===
I am looking for a little friend of mine.
Your riddle for it goes like this:
"I’m rolled but I’m not a ball.
I have several faces but I’m not a group of people.
I’m covered in spots but I don’t have acne.
I’m sometimes blown on but I’m not hot.
I’m a cube but I’m not made of ice."
...
    +[What?]
        -> reflectingTime
    +[No.]
        ~ changeDialogue("sulking")
        -> DONE
    +[Just say me what I should look for.]
        -> reflectingTime
        
=== reflectingTime ===
Okay.
Gotta look at my own reflection now.
Byeeee.
        ~ startQuest("The Die")
        -> DONE
