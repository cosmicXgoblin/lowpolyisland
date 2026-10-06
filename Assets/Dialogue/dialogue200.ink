 EXTERNAL startQuest(questName)

[The tree seems to have grown a few tiny sakura blossoms.
You hear a rustling in its treecrown, then a voice with a hardly noticeable cooing in it speaks to you:]
HELLO HOOMIN.
    +[Ehr, hello?]
    -> helloFromTheTreecrown
    +[Pigeon, is that you?]
    -> notAPigeon
    +[...]
    -> silence
 
=== helloFromTheTreecrown ===
HOOMIN.
I AM THE TREE OF THIS ISLAND.
I HEARD THE GOODLOOKING PIGEON PROMISED YOU TO HELP YOU ESCAPE, YES?
...
    +[Goodlooking?]
    -> helloFromTheTreecrown
    +[Pigeon, is that you?]
    -> notAPigeon
    +[...]
    -> silence
    
=== notAPigeon ===
HA HA HA.
NO HUMAN. I AM A TREE.
BUT I WOULD BE FLATTERD TO BE SUCH A GOODLOOKING AND WISE FELLA LIKE YOUR PIGEON FRIEND.
...
    +[Alright, I believe you.]
    -> itsATree
    +[Pigeon, is that you?]
    -> notAPigeon
    +[...]
    -> silence
    
=== silence ===
I KNOW A WAY IT WILL HELP YOU.
IT LOST A COIN A LONG, LONG TIME AGAIN.
YOU KNOW, IT WAS CURSED SO IT CAN'T LOOK FOR IT ITSELF.
...
    +[Where can i find it?]
    -> itsATree
    +[You sure are sounding like the pigeon.]
    -> reallyNotAPigeon
    +[...]
    -> theCoin
    
=== itsATree ===
[You hear a soft cooing, something that sounds a lot like "dumb hoomin" before the voice continues:]
-> theCoin

=== reallyNotAPigeon ===
AS I SAID BEFORE, I AM NOT THIS PIGEON.
NOW, HOOMIN, LISTEN TO MY WORDS:
-> theCoin

=== theCoin ===
THE PIGEON GOD LOST IT'S MOST BELOVED VALUABLE, A SHINY ROUND OBJECT.
IT WAS LAST SEEN ON THE BEACH, WHEN THE PIGEON WAS TALKING TO THE SPARSE FLORA.
...
    +[Jup.]
    -> AnewQuest
    +[Whatever.]
    -> AnewQuest
    +[...]
    -> AnewQuest
    
=== AnewQuest ===
...
I WILL NOW GO BACK TO MY SLUMBER MY FRIEND, SO DON'T EXPECT TO TALK TO ME AGAIN.
BUT IF YOU FIND THE TREASURE, THE GOD OF THE SEA AND THE SKY WILL RETURN AND TAKE YOU HOME.
    ~ startQuest("the Coin")
    -> DONE




