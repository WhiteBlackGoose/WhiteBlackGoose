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
                li [] [ a [_href "https://stallman.org/facebook.html" ] [ Text "About Facebook" ] ]
                li [] [ a [_href "https://stallman.org/apple.html" ] [ Text "About Apple" ] ]
                li [] [ a [_href "https://stallman.org/microsoft.html" ] [ Text "About Microsoft" ] ]
                li [] [ a [_href "https://stallman.org/"] [ Text "stallman.org" ] ]
                li [] [ a [_href "https://ashley143.gay/"] [ Text "ashley143.gay" ] ]
                li [] [ a [_href "https://michael.stapelberg.ch/"] [ Text "michael.stapelberg.ch" ] ]
                li [] [ a [_href "https://stop-using-nix-env.privatevoid.net/"] [ Text "Stop using nix-env" ] ]
            ]
        ]
    ]
}
