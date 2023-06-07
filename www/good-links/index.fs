module www.good_links.index

open Giraffe.ViewEngine
open Page

let html = PageWrap.wrap www.``static``.styles.css {
 title = "Good links"
 url = "good-links"
 filename = "index.html"
 contents = [
  h2 [] [ Text "Privacy &amp; Security" ]
  p [] [
   ul [] [
    let links = [
     "https://tails.boum.org/", "Tails" 
     "https://www.whonix.org/", "Whonix"
     "https://www.gnu.org/software/librejs/", "LibreJS"
     "https://www.torproject.org/", "Tor Browser"
     "https://ens.domains/", "ENS"
     "https://matrix.org/", "Matrix protocol"
     "https://www.farcaster.xyz/", "Farcaster"
     "https://www.signal.org/", "Signal"
     "https://www.passwordstore.org/", "Password Store"
    ]
    for url, name in links do
     li [] [ a [_href url] [ Text name ] ]
   ]
  ]

  h2 [] [ Text "These disrespect your freedom" ]
  p [] [
   ul [] [
    let links = [
     "https://stallman.org/facebook.html" , "Facebook" 
     "https://stallman.org/apple.html" , "Apple" 
     "https://stallman.org/microsoft.html" , "Microsoft" 
     "https://contrachrome.com/", "Google Chrome"
     "https://wikileaks.org/", "Governments"
    ]
    for url, name in links do
     li [] [ a [_href url] [ Text name ] ]
   ]
  ]

  h2 [] [ Text "Other" ]
  p [] [
   ul [] [
    let links = [
     "https://stallman.org/", "stallman.org - author of GNU" 
     "https://ashley143.gay/", "ashley143.gay - author of poketube.fun" 
     "https://michael.stapelberg.ch/", "i3wm author's blog" 
     "https://stop-using-nix-env.privatevoid.net/", "Stop using nix-env" 
     "https://www.kalzumeus.com/2010/06/17/falsehoods-programmers-believe-about-names/", "About peoples' names in software"
     "https://tim.dreamwidth.org/1762846.html", "How To Exclude Women From Your Technical Community"
    ]
    for url, name in links do
     li [] [ a [_href url] [ Text name ] ]
   ]
  ]

  p [] [ Text "If you think something belongs to this list, feel free to add it by pressing button 'Edit'" ]
 ]
}
