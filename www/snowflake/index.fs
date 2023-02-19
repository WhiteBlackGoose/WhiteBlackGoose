module www.snowflake.index

open Giraffe.ViewEngine
open Page

let html = PageWrap.wrap www.``static``.styles.css {
    title = "Snowflake: help others bypass censorship!"
    url = "snowflake"
    filename = "index.html"
    contents = [
        iframe [_src "https://snowflake.torproject.org/embed.html"; _width "320"; _height "240" ] []
        p [] [ Text "Here's a short summary" ]
        h3 [] [ Text "What you need" ]
        ul [] [
            li [] [ Text "Free internet" ]
            li [] [ Text "Press button enable" ]
            li [] [ Text "Keep your tab open" ]
        ]
        h3 [] [ Text "Am I safe running it?" ]
        p [] [ Text "Quote: \"There is no need to worry about which websites people are accessing through your Snowflake proxy. Their visible browsing IP address will match their Tor exit node, not yours.\"" ]
        p [] [ a [_href "https://snowflake.torproject.org/"] [ Text "More info" ] ]
    ]
}
