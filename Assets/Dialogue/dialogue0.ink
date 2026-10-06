EXTERNAL changeDialogue(newDialogue)

Hey you, skintoned fleshthingy.
Yes, you.
...
What, why are you staring?
...
    +[Did i eat some crazy mushrooms?]
        -> mushrooms
    +[YOU CAN TALK?]
        -> talkingPigeon
    +[Finally somehting happens here.]
        -> mainCharacterSyndrome

=== mushrooms ===
I mean, possibly?
Maybe everything we experience is just a dream by something
very, very big and we don't exist at all.
Maybe everything is a simulation.
Maybe i am god in the shape of a pigeon.
Maybe you should've talked to a therapist years ago.
-> SecondChoices

=== talkingPigeon ===
Yes.
And i am sad to announce that i can also understand you AND you
are the only one to talk to here at the moment.
So, it seems like we are stuck with each other.
But do you see me complain?
No.
That's because i am trying to be polite you little fuckwit.
-> SecondChoices

=== mainCharacterSyndrome ===
Oh no, another one with main character syndrome.
...
    +[What?]
        -> SecondText
    +[WHAT?]
        -> SecondText
    +[...]
        -> SecondText

=== SecondChoices ===
    +[What?]
        -> SecondText
    +[WHAT?]
        -> SecondText
    +[...]
        -> SecondText
        
=== SecondText ===
Ehr, i mean:
LOVELY hoomin, it is I, the Pigeon God of the sky, and, ehr, the
other, wetter sky.
...
    +[Am I your prophet??]
        -> prophet
    +[Like, the water?]
         -> wetSky
    +[...]
        -> silentOne
      
 === prophet ===
... Yes.
Yes, you are.
I am your god and you are my prophet and i have some que-, ehr,
tasks for you to do.
...
    +[I AM THE CHOSEN ONE!]
        -> chosenOne
    +[K.]
        -> silentOne
    +[Or you could be a superhero and i could be your sidekick?]
         -> sidekickOne     
      
=== wetSky ===
Sigh.
Yes, my little daft nut, like the water.
...
    +[Why are you insulting me?]
        -> snowflake
    +[I have a severe nut allergy.]
        -> nutAllergy
    +[...]
       -> silentOne

=== snowflake ===
I have a deep fear of rejection and intimate connections, so i tend to push
those away that could make me feel something.
...
    +[Jeez.]
        -> PreludeQuest1
    +[Can we just do your stupid quest?]
        -> PreludeQuest1
    +[...]
       -> silentOne

=== sidekickOne ===
No.
...
    +[I think I may be depressed.] // #depressedOne
        -> PreludeQuest1
    +[Can we just do your stupid quest?]
        -> PreludeQuest1
    +[...]
       -> silentOne

=== silentOne ===
You are a silent one, I see.
...
    +[No, i just don't want to talk to you.]
        -> rudeOne
    +[The less you talk, the more intelligent you seem.]
        -> intelligentOne
    +[...]
       -> silentOne

=== nutAllergy ===
That's not the setup to a bad joke, is it?
...
    +[I would NEVER make a joke about allergies!]
        -> PreludeQuest1
    +[Can we just do your stupid quest?]
        -> PreludeQuest1
    +[DEEZ NUTS!]
       ->  PreludeQuest1
       
=== rudeOne ===
Too bad we are stuck here with each other.
        -> PreludeQuest1
        
=== intelligentOne ===
And that works for you?
...
    +[No.]
        -> PreludeQuest1
    +[Can we just do your stupid quest?]
        -> PreludeQuest1
    +[Yes.]
       -> PreludeQuest1
       
=== chosenOne ===
You are, indeed.
You are the most special person on this whole island.
...
And the only one.
        -> PreludeQuest1
        
=== PreludeQuest1 ===
Alright, moving on.
Talk to me when you are ready for the quest.
        ~ changeDialogue("quest1")
        -> DONE





