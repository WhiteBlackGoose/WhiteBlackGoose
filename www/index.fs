module www.index

open Giraffe.ViewEngine
open Page

let html = PageWrap.wrap www.``static``.styles.css {
    title = "WBG's"
    url = "."
    filename = "index.html"
    contents = [
        p [] [ 
            Text $"""Hello."""
        ]
        h2 [] [ anc "articles"; Text "My Articles" ]
        yield! www.blog.index.articlesListHtml
        h2 [] [ anc "projects"; Text "My Projects" ]
        yield! www.projects.index.projectsListHtml
    ]
}
