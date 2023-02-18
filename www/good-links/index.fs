module www.good_links.index

open Giraffe.ViewEngine
open Page

let html = PageWrap.wrap www.``static``.styles.css {
    title = "Good links"
    url = "good-links"
    filename = "index.html"
    contents = [
        p [] [
            ul [] [
                let links = [
                    "https://stallman.org/facebook.html" , "About Facebook" 
                    "https://stallman.org/apple.html" , "About Apple" 
                    "https://stallman.org/microsoft.html" , "About Microsoft" 
                    "https://stallman.org/", "stallman.org - author of GNU" 
                    "https://ashley143.gay/", "ashley143.gay - author of poketube.fun" 
                    "https://michael.stapelberg.ch/", "i3wm author's blog" 
                    "https://stop-using-nix-env.privatevoid.net/", "Stop using nix-env" 
                    "https://contrachrome.com/", "Contra Chrome!"
                    "https://tails.boum.org/", "Tails - free secure OS" 
                    "https://wikileaks.org/", "Leaks of governments"
                    "https://www.gnu.org/software/librejs/", "LibreJS"
                    "https://www.torproject.org/", "Tor Browser"
                    "https://www.kalzumeus.com/2010/06/17/falsehoods-programmers-believe-about-names/", "About peoples' names in software"
                ]
                for url, name in links do
                    li [] [ a [_href url] [ Text name ] ]
            ]
        ]
        p [] [ Text "If you think something belongs to this list, feel free to add it by pressing button 'Edit'" ]
    ]
}
