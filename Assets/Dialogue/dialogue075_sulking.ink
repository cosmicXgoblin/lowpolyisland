EXTERNAL startQuest(questName)
EXTERNAL changeDialogue(newDialogue)

You done sulking?
Will you help me now?
...
    +[No thank you.]
        -> DONE 
        ~ changeDialogue("sulking")
    +[Sure, I'll help you.]
        -> helpIsOnTheWay
    +[What's in it for me?]
        -> altruismIsAScam
        
=== rudeHoomin ===
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
        -> DONE // and bool
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
I am looking for a little fiend of mine.
The riddle for it goes like this:
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

