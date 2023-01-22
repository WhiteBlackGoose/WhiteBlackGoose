module InternalArticleDef

open Giraffe.ViewEngine

type TextPage = {
    title : string
    contents : XmlNode list
}
