VAR health = 100
VAR sanity = 100

Hello #Toffee

My health is {health} and my sanity is {sanity}

How are you? ajsssjdaosdasnd   iqwe sndnmnd jk sjda skdal lkjl kkjd aksjdlakjsdl aj

iajeowqnd

asdas #bunny

-> ChoiceSelection1

==ChoiceSelection1==
What to do?
+[Toffee] -> Toffee
+[TV] -> TV
+[Pillow] -> Sleep

==ChoiceSelection2==
*[Toffee] -> Toffee
*[TV] -> TV
*[Pillow] -> Sleep

==Toffee==

{Play_Toffee()} Toffee is cute!

My health is {health} and my sanity is {sanity}

-> ChoiceSelection1

->END

==TV==

You watch TV!

{watch_TV()}

My health is {health} and my sanity is {sanity}

->END

==Sleep==
You fell into a deep sleep...Zzz

->END

== function watch_TV ==
~ health = health - 20

== function Play_Toffee ==
~ health = health + 20
~ sanity = sanity + 20





