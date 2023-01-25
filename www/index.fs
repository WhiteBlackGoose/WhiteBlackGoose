module www.index

open Giraffe.ViewEngine
open Page
open www.``static``.media

let html = PageWrap.wrap www.``static``.styles.css {
    title = "WBG's"
    url = "."
    filename = "index.html"
    contents = [
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
        hr []
        p [_style "text-align: center;"] [
            let urls = [
                $"""{_a (Utils.locAwarePath www.blog.index.html.url) "Blog"}"""
                $"""{_a (Utils.locAwarePath www.projects.index.html.url) "Projects"}"""
                $"""{_a "https://github.com/WhiteBlackGoose" "Github"}"""
                $"""{_a (Utils.locAwarePath www.gpg.index.html.url) "My GPG key"}"""
            ]
            Text "•&nbsp;"
            for url in urls do
                span [] [ Text url ]
                Text "&nbsp;•&nbsp;"
        ]
        hr []
        p [] [
            table [_style "width: 80%; padding-left: 10%;"] [ tr [] [
            for icon in [icons.NixOS; icons.GNU; icons.NeoVim "."; icons.CSharp; icons.FSharp; icons.dotnet; icons.git; icons.bitcoin] do
                td [] [ icon ]
            ]]
        ]
        h2 [] [ anc "articles"; Text "My Articles" ]
        yield! www.blog.index.articlesListHtml

        h2 [] [ anc "projects"; Text "My Projects" ]
        yield! www.projects.index.projectsListHtml

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
