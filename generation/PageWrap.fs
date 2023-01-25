module PageWrap

open Giraffe.ViewEngine
open Page

type WrappedPage = {
    url : string
    filename : string
    contents : XmlNode
    title : string
}

let wrap css ({ title = pageTitle; url = url; filename = filename; contents = contents } : Page) : WrappedPage = 
    { url = url
      filename = filename
      title = pageTitle
      contents = 
        html [] [
            title [] [ Text pageTitle ]
            head [] [
                link [_rel "icon"; _type "image/png"; _href "https://avatars.githubusercontent.com/u/31178401"]
                link [_rel "stylesheet"; _type "text/css"; _href "https://fonts.googleapis.com/css?family=Overpass+Mono"]
                link [_rel "stylesheet"; _type "text/css"; _href "https://fonts.googleapis.com/css?family=Ubuntu+Mono"]
                css
            ]
            body [] [
                let sp = span [_style "color: gray;"] [ Text "|" ] |> RenderView.AsString.htmlNode
                let comp f = f [_style "padding: 12px; color: gray;"] [
                    let navig = 
                        if url = "." then 
                            ""
                        else
                            let elevationCount = url |> String.filter ((=) '/') |> String.length
                            let elevation = 
                                [ for _ in 1 .. elevationCount + 1 do "../" ] |> String.concat ""
                            let homePath = Utils.locAwarePath elevation
                            let upPath = Utils.locAwarePath ".."
                            $"""{_a homePath "Home"} {sp} {_a upPath "Up"} {sp}"""

                    let edit =
                        a [_href ("https://github.com/WhiteBlackGoose/WhiteBlackGoose/blob/master/www" </> url </> "index.fs")] [ Text "Edit" ] |> RenderView.AsString.htmlNode
                            
                    Text $"""WhiteBlackGoose' website {sp} {navig} {edit} {sp} The content is under CC BY-NC 4.0 and source code is under GPLv3"""
                ]
                comp header
                div [_class "article-body"] [
                h1 [] [ Text pageTitle ]
                yield! contents
                ]
                comp footer
            ]
        ]
    }
