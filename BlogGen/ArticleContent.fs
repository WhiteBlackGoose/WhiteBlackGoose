module ArticleContent

open Giraffe.ViewEngine

type ArticleContent = {
    title : string;
    body : XmlNode list;
}
