 EXTERNAL other(name)

Hey Hoomin.
It seems like you found my precious shiny thing.
...
    +[Jep.]
    -> preciousShinyThing
    +[And it's mine now.]
    -> aThief
    +[...]
    -> silence

=== silence ===
Nah, I am not dealing with this again.
I will repeat myself:
Hey Hoomin.
It seems like you found my precious shiny thing.
...
    +[Jep.]
    -> preciousShinyThing
    +[And it's mine now.]
    -> aThief
    +[...]
    -> silence

=== aThief ===
Wha-What?
Hoomin. I should've known.
All of you are the same! Nothing but thieves.
Do you like the view? All this water around you?
No? Well, sucks, because this will be your prison now!
Maybe you should've thought twice about angering A GOD.
...
    +[I am sorry. You can have it.]
    -> thisIsUrHome
    +[Fuck you.]
    -> gameOver
    +[...]
    -> thisIsUrHome

=== preciousShinyThing ===
So...
...
    +[So...]
    -> preciousShinyThing
    +[What?]
    -> giveItToMe
    +[...]
    -> silenceAgain
    
=== silenceAgain ===
No. I will not be dealing with this again.
I will repeat myself:
    -> preciousShinyThing
    
=== giveItToMe ===
Give it to me.
...
    +[Okay.]
    -> friends
    +[No.]
    -> aThief
    +[...]
    -> silenceAgainAndAgain
    
=== silenceAgainAndAgain ===
Hoomin. What is wrong with you. Do you really thing this works? 
Do you think you are mysterious and strong and whatnot?
No. No, you are not.
You're making the impression you are not able to formulate complete sentences.
It's not endearing. Its unnerving.
I. WILL. REPEAT. MYSELF. AGAIN:
    -> giveItToMe
    
=== friends ===
Thank you, hoomin.
...
I am sorry if i was not exactly friendly to you.
...
It is hard being a god.
And i am very lonely.
But it was nice, having you here for a bit. I'd like to think of you as a friend.
...
    +[Ew.]
    -> gameOver
    +[I'd like that!]
    -> foreverTogether
    +[...]
    -> silenceIsYourOnlyFriend
    
=== silenceIsYourOnlyFriend ===
I know Hoomin, I know.
It's hard to imagine such a perfect personality like me to be gracious enough to allow you this.
And believe me, if I had other options ... well.
But here we are.
    -> foreverTogether
    
=== foreverTogether ===
The last time i had one it was a long, long time ago.
I think their remains are still somewhere here on the island?
Anyway. Go to sleep, friend, and i will see you soon.
...
    +[I thought i could, you know, go home now?]
    -> thisIsUrHome
    +[what?]
    -> thisIsUrHome
    +[...]
    -> thisIsUrHome
    
=== thisIsUrHome ===
[But it was too late.
The Pigeon was already vanishing in the clouds and you were still here, on this island.
Would he come again?
We'll never know.
Or, maybe, we do. If i got enough spare time to work more on this.
Thanks for playing, feel free to report any bugs back to me.]
(cosmicgoblingames)
    ~ other("gameOver")
-> DONE

=== gameOver ===
    ~ other("gameOver")
    -> DONE
