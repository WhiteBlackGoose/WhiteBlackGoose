module Articles.MyValues
open Giraffe.ViewEngine


let content { bold = bold; italics = italics; } =
{
    title = "What the World could be Like"
    body = [
        h1 [] [ Text "MyValues" ]
        p [] [ Text "Hi. I'm WhiteBlackGoose, and here is what I think is right and wrong. These values are what possible in today's world. " ]
        br [] []
        hr [] []
        br [] []
        p [] [
            h2 [] [ Text "I'm pro..." ]
            ul [] [
                il [] [ Text "Individualism" ]
            ]
        ]
    ]
}
