module www.comics.index

open Giraffe.ViewEngine
open Page


let htmlsMap (_, comicName, comicUrl) = PageWrap.wrap www.``static``.styles.css {
 title = comicName
 url = "comics/" + comicUrl
 filename = "index.html"
 contents = [
  img [
   _src <| Utils.locAwarePath $"static/comics/{comicUrl}.png"
   _style "width: 100%;"
   ]
 ]
}

let comics = [
 ("2023-06-18", "For the Nerds", "for-nerds")
]

let htmls = List.map htmlsMap comics

let html = PageWrap.wrap www.``static``.styles.css {
 title = "Comics"
 url = "comics"
 filename = "index.html"
 contents = [
  ul [] [
   for (date, name, url) in comics do
    li [] [
     Text date
     Text " "
     a [ _href <| Utils.locAwarePath $"comics/{url}" ] [ Text name ]
    ]
  ]
 ]
}
