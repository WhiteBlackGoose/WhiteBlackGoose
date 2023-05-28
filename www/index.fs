module www.index

open Giraffe.ViewEngine
open Page
open www.``static``.media

let html = PageWrap.wrap www.``static``.styles.css {
 title = "WBG's"
 url = "."
 filename = "index.html"
 contents = [
  div [_style "display: grid; grid-template-columns: 5fr 2fr; grid-gap: 20px;"] [
   main [] [
    p [] [ Text $"""Hello. This is WhiteBlackGoose.""" ]
    p [] [ 
     Text $"""
     I'm a {_a "https://www.gnu.org/philosophy/free-sw.en.html" "Free Software"} enthusiast,
     contributor and maintainer of a couple of Free and Open-Source projects.
     """ ]
    p [] [
     Text $"""
     I'm a member of {_a "https://angouri.org/" "Angouri"}, {_a "http://dotnetfoundation.org/" ".NET Foundation"}, and {_a "https://www.fsf.org/" "Free Software Foundation"}, and author of {_a "http://github.com/asc-community/AngouriMath" "AngouriMath"}.
     """
    ]
   ]
   aside [] [
    h3 [] [ Text "Recently added" ]
    p [] [
     ul [] [
      li [] [ a [_href (Utils.locAwarePath www.blog.nixos.index.html.url) ] [ Text "I love NixOS" ] ]
      li [] [ a [_href "https://stallman.org/facebook.html"] [ Text "About Facebook" ] ]
      li [] [ a [_href (Utils.locAwarePath www.blog.yyyy_mm_dd.index.html.url) ] [ Text "yyyy-mm-dd is best" ] ]
     ]
    ]
   ]
  ]
  hr []
  p [_style "text-align: center;"] [
   let urls = [
    $"""{_a (Utils.locAwarePath www.blog.index.html.url) "Blog"}"""
    $"""{_a (Utils.locAwarePath www.projects.index.html.url) "Projects"}"""
    $"""{_a "https://github.com/WhiteBlackGoose" "Github"}"""
    $"""{_a (Utils.locAwarePath www.gpg.index.html.url) "My GPG key"}"""
    $"""{_a (Utils.locAwarePath www.good_links.index.html.url) "Good links"}"""
    $"""{_a (Utils.locAwarePath www.snowflake.index.html.url) "Snowflake"}"""
   ]
   Text "•&nbsp;"
   for url in urls do
    span [] [ Text url ]
    Text "&nbsp;•&nbsp;"
  ]
  hr []
  p [] [
   table [_style "display: flex; justify-content: center"] [ tr [] [
   for icon in [icons.NixOS; icons.GNU; icons.Tor; icons.NeoVim; icons.LaTeX; icons.FSharp; icons.rust; icons.haskell; icons.git; icons.ens; icons.eth] do
    td [] [ icon "30" ]
   ]]
  ]

  h2 [] [ anc "projects"; Text "Projects I made" ]
  yield! www.projects.index.projectsListHtml www.projects.index.myProjects

  h2 [] [ anc "projects"; Text "Projects I contributed to" ]
  yield! www.projects.index.projectsListHtml www.projects.index.contributedProjects

  h2 [] [ anc "pulls"; Text "Pull requests" ]
  pre [] [
  Text $"""
{_a "https://github.com/search?o=desc&q=is%3Aclosed+is%3Apull-request+author%3AWhiteBlackGoose+archived%3Afalse+is%3Amerged&s=updated&type=Issues" "All"} 
├─ {_a "https://github.com/search?o=desc&q=is%3Aclosed+is%3Apull-request+author%3AWhiteBlackGoose+archived%3Afalse+is%3Amerged+org%3Aasc-community&s=updated&type=Issues" "Angouri"} 
│  ├─ {_a "https://github.com/search?o=desc&q=is%3Aclosed+is%3Apull-request+author%3AWhiteBlackGoose+archived%3Afalse+is%3Amerged+repo%3Aasc-community%2FAngouriMath&s=updated&type=Issues" "AngouriMath"} 
│  └─ {_a "https://github.com/search?o=desc&q=is%3Aclosed+is%3Apull-request+author%3AWhiteBlackGoose+archived%3Afalse+is%3Amerged+-repo%3Aasc-community%2FAngouriMath+org%3Aasc-community&s=updated&type=Issues" "Other"} 
├─ {_a "https://github.com/search?o=desc&q=is%3Aclosed+is%3Apull-request+author%3AWhiteBlackGoose+archived%3Afalse+is%3Amerged+org%3Adotnet&s=updated&type=Issues" ".NET"} 
│  ├─ {_a "https://github.com/search?o=desc&q=is%3Aclosed+is%3Apull-request+author%3AWhiteBlackGoose+archived%3Afalse+is%3Amerged+repo%3Adotnet%2FSilk.NET&s=updated&type=Issues" "Silk.NET"} 
│  └─ {_a "https://github.com/search?o=desc&q=is%3Aclosed+is%3Apull-request+author%3AWhiteBlackGoose+archived%3Afalse+is%3Amerged+-repo%3Adotnet%2FSilk.NET+org%3Adotnet&s=updated&type=Issues" "Other"} 
└─ {_a "https://github.com/search?o=desc&q=is%3Aclosed+is%3Apull-request+author%3AWhiteBlackGoose+archived%3Afalse+is%3Amerged+org%3Aplotly&s=updated&type=Issues" "Plotly"} 
   ├─ {_a "https://github.com/search?o=desc&q=is%3Aclosed+is%3Apull-request+author%3AWhiteBlackGoose+archived%3Afalse+is%3Amerged+org%3Aplotly+repo%3Aplotly%2FPlotly.NET&s=updated&type=Issues" "Plotly.NET"} 
   └─ {_a "https://github.com/search?o=desc&q=is%3Aclosed+is%3Apull-request+author%3AWhiteBlackGoose+archived%3Afalse+is%3Amerged+-org%3Aasc-community+-org%3Adotnet+-org%3Aplotly&s=updated&type=Issues" "Other"} 
  """
  ]

  h2 [] [ anc "articles"; Text "My articles" ]
  p [] [
   ul [_style "column-count: 2"] [
    for { link = url; shortTitle = title; } in www.blog.index.articles do
     li [] [ a [_href url] [ Text title ] ]
   ]
  ]

  h2 [] [ anc "fun"; Text "Fun" ]
  p [] [
   ul [] [
    li [] [ a [_href (Utils.locAwarePath www.misc.os_tierlist.index.html.url)] [Text "My OS tier list"] ]
   ]
  ]

  h2 [] [ anc "contacts"; Text "Contacts" ]
  p [] [
   a [_href "https://stallman.org/facebook.html"; _style "text-align: right;"] [icons.noFacebook]
   ul [] [
    li [] [ Text $"""E-mail: wbg at angouri.org""" ]
    li [] [ Text $"""GitHub, Reddit: WhiteBlackGoose""" ]
   ]
  ]
 ]
}
