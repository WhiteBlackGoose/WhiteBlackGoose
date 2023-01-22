module ArticleView

open Giraffe.ViewEngine

let articleView { title = title; body = body; } : Xml Node =
    html [] [
        title [] [ Text title ]
        head [] []
        yield! body
    ]
