module www.snowflake.index

open Giraffe.ViewEngine
open Page

let html = PageWrap.wrap www.``static``.styles.css {
 title = "Snowflake: help others bypass censorship!"
 url = "snowflake"
 filename = "index.html"
 contents = [
  iframe [_src "https://snowflake.torproject.org/embed.html"; _width "320"; _height "240"; 
   _style "
    float: left;
    margin: 50px;
    height: 350px;
    border: none;
    box-shadow: 0px 0px 20px rgba(0, 0, 0, 0.4);
    border-radius: 20px;
    " ] []
  div [ _src "align: right" ] [
   p [] [ Text "Here's a short summary" ]
   h3 [] [ Text "What you need" ]
   ul [] [
    li [] [ Text "Free internet" ]
    li [] [ Text "Press button enable" ]
    li [] [ Text "Keep this tab open" ]
   ]
   h3 [] [ Text "Am I safe running it?" ]
   p [] [ Text "Quote: \"There is no need to worry about which websites people are accessing through your Snowflake proxy. Their visible browsing IP address will match their Tor exit node, not yours.\"" ]
   p [] [ a [_href "https://snowflake.torproject.org/"] [ Text "More info" ] ]
   p [] [ Text "By the way, you can also self-host snowflake, get an extension from your browser, or put it in your own website:" ]
   textarea [ _readonly; _width "100%";
    _style "width: 100%;
    background: #333;
    border: none;
    color: white;"
   ] [
    Text "<iframe src=\"https://snowflake.torproject.org/embed.html\" width=\"320\" height=\"240\" frameborder=\"0\" scrolling=\"no\"></iframe>" 
   ]
  ]
 ]
}
