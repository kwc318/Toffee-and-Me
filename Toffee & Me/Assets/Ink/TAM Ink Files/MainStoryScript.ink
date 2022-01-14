VAR health = 100
VAR sanity = 100

Hello #Toffee

My health is {health} and my sanity is {sanity}

How are you? ajsssjdaosdasnd   iqwe sndnmnd jk sjda skdal lkjl kkjd aksjdlakjsdl aj

asdas #bunny

-> ChoiceSelection

==ChoiceSelection==

*[Toffee] -> Toffee
*[TV] -> TV
*[Pillow] -> Sleep

==Toffee==

Toffee is cute!

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





