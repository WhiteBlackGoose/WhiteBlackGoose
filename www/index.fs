module www.index

open Giraffe.ViewEngine
open Page

let html = PageWrap.wrap www.``static``.styles.css {
    title = "WBG's"
    url = "."
    filename = "index.html"
    contents = [
        let _a url name = a [_href url] [ Text name ] |> Giraffe.ViewEngine.RenderView.AsString.htmlNode
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
        h2 [] [ anc "articles"; Text "My Articles" ]
        yield! www.blog.index.articlesListHtml
        h2 [] [ anc "projects"; Text "My Projects" ]
        yield! www.projects.index.projectsListHtml
    ]
}
