module PageWrap

open Giraffe.ViewEngine
open Page
open Utils

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
                div [
                    _style """
                        width: 100%;
                        height: 10px;
                        padding: 0;
                        margin: 0;
                        float: none;
                        position: absolute;
                        top: 0;
                        left: 0;
                        background: linear-gradient(90deg, rgb(0, 87, 183) 50%, rgb(255, 215, 0) 50%, rgb(255, 215, 0) 50%);
                    """
                ] []
                let sp = span [_style "color: gray;"] [ Text "|" ] |> RenderView.AsString.htmlNode
                let comp f = f [_style "padding: 12px; color: gray;"] [
                    let navig = 
                        if url = "." then 
                            ""
                        else
                            let elevationCount = url |> String.filter ((=) '/') |> String.length
                            let elevation = 
                                [ for _ in 1 .. elevationCount + 1 do "../" ] |> String.concat ""
                            let homePath = Utils.locAwarePath "."
                            let upPath = Utils.fixUrlEnding ".."
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
