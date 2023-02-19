module www.snowflake.index

open Giraffe.ViewEngine
open Page

let html = PageWrap.wrap www.``static``.styles.css {
    title = "Snowflake"
    url = "snowflake"
    filename = "index.html"
    contents = [
        p [] [ Text "Fuck censorship. Help others bypass it!" ]
        p [] [ a [_href "https://snowflake.torproject.org/"] [ Text "More info" ] ]
        iframe [_src "https://snowflake.torproject.org/embed.html"; _width "320"; _height "240" ] []
    ]
}
