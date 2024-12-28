module www.good_links.index

open Giraffe.ViewEngine
open Page

let html = PageWrap.wrap www.``static``.styles.css {
 title = "Good links/resources"
 url = "good-links"
 filename = "index.html"
 contents = [
  h2 [] [ Text "Programming" ]
  p [] [
   Text "These articles/books I read and can personally recommend self-educating."
  ]
  p [] [
   h3 [] [ Text "General" ]
   ul [] [
    li [] [ a [_href "https://en.wikibooks.org/wiki/X86_Assembly"] [ Text "x86 Assembly" ] ]
    li [] [
     a [_href "https://eli.thegreenplace.net/2011/01/23/how-debuggers-work-part-1/"] [
      Text "How Debuggers Work"
     ]
     Text " ("
     a [_href "https://eli.thegreenplace.net/2011/01/23/how-debuggers-work-part-1/"] [ Text "part I" ]
     Text ", "
     a [_href "https://eli.thegreenplace.net/2011/01/27/how-debuggers-work-part-2-breakpoints/"] [ Text "part II" ]
     Text ", "
     a [_href "https://eli.thegreenplace.net/2011/02/07/how-debuggers-work-part-3-debugging-information"] [ Text "part III" ]
     Text ")"
    ]
   ]
   h3 [] [ Text "Rust" ]
   ul [] [
    let links = [
     "https://marabos.nl/atomics/", "Atomics"
     "https://rust-lang.github.io/async-book/intro.html", "Async book"
     "https://veykril.github.io/tlborm/", "Macros book"
    ]
    for url, name in links do
     li [] [ a [_href url] [ Text name ] ]
   ]
   h3 [] [ Text ".NET" ]
   ul [] [
    let links = [
     None, "CLR via C# 4-th edition"
     None, "Pro .NET Memory Management"
     None, "Pro .NET Benchmarking"
    ]
    for url, name in links do
     match url with
     | Some(url) -> li [] [ a [_href url] [ Text name ] ]
     | None -> li [] [ Text name ]
   ]
  ]
  br []
  hr []
  br []
  h2 [] [ Text "Justice" ]
  p [] [
   ul [] [
    let links = [
     "https://tim.dreamwidth.org/1762846.html", "How To Exclude Women From Your Technical Community"
     "https://996.icu/#/en_US", "996 - unfair work schedule in Mainland China"
     "https://wikileaks.org/", "Governments"
    ]
    for url, name in links do
     li [] [ a [_href url] [ Text name ] ]
   ]
  ]

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

  h2 [] [ Text "This software disrespects your freedom" ]
  p [] [
   ul [] [
    let links = [
     "https://stallman.org/facebook.html" , "Facebook" 
     "https://stallman.org/apple.html" , "Apple" 
     "https://stallman.org/microsoft.html" , "Microsoft" 
     "https://contrachrome.com/", "Google Chrome"
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
     "https://michael.stapelberg.ch/", "i3wm author's blog" 
     "https://stop-using-nix-env.privatevoid.net/", "Stop using nix-env" 
     "https://www.kalzumeus.com/2010/06/17/falsehoods-programmers-believe-about-names/", "About peoples' names in software"
    ]
    for url, name in links do
     li [] [ a [_href url] [ Text name ] ]
   ]
  ]

  p [] [ Text "If you think something belongs to this list, feel free to add it by pressing button 'Edit'" ]
 ]
}
