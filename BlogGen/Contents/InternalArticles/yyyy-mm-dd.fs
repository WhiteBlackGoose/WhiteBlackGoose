module InternalArticles.YyyyMmDd

open Giraffe.ViewEngine
open InternalArticleDef

let page = {
    title = "yyyy-mm-dd is the best date format"
    contents = [
        p [] [
            Text $"""
            I keep seeing Europeans and Americans arguing on reddit whether
            it should be DD/MM/YYYY or MM/DD/YYYY. I've always disagreed with
            both, let me give you a few reasons why.
            {it "Disclaimer: the arguments here are mostly for people who read from left to right"}
            """
        ]
        br []
        hr []
        br []

        h2 [] [ Text $"""1. Consistency with other measurements""" ]
        p [] [
            Text $"""
            First of all, how do we write numbers? Take {bo "645"}. Its first
            (reading from the left) digit is {bo "6"}, the most significant digit. So
            when you consider a price of a product, you most likely will care more
            about its major units than those minor (e. g. "six hundred dollars" is not 
            much different from "six hundred fourty five").
            """
        ]
        p [] [
            Text $"""
            Now, let's take something else. For example, time, which we write as
            "15:45" and read starting from its major units. See the pattern?
            """
        ]
        p [] [
            Text $"""
            In {bo "yyyy-mm-dd"} it's the same. Starting from the most major unit,
            ending with a minormost one.
            """
        ]
        
        h2 [] [ Text $"""2. Universality for daily usage""" ]
        p [] [
            Text $"""
            An argument for MM/DD/YYYY and DD/MM/YYYY is that they're supposedly
            easier to work with for people in everyday life. I disagree with it.
            """
        ]
        p [] [
            Text $"""
            What is our use of date and time? Surely the most basic option would
            be the precise moment in time, e. g. year 2022, month 10, day 20, hour 12, minute 16, second 10. But it's impractical for daily life, it's long, inconvenient, error-prone.
            """
        ]
        p [] [
            Text $"""
            Our universal format allows to {it "cut"} any continuous interval from ISO8601 ({bo "YYYY-MM-DD HH:mm:ss"}) which still makes perfect sense. For example, you want to hold a party soon, so you cut (YYYY-{bo "MM-DD HH"}:mm:ss). Or you want to research when Napoleon started working on his Napoleonic plans, which would be ({bo "YYYY-MM"}-DD HH:mm:ss). Or a lecture starts soon, you're perhaps interested in (YYYY-MM-DD HH:{bo "mm:ss"}). Likewise, a full date and a full time are also continuous intervals taken from this universal format!
            """
        ]

        h3 [] [ Text $"""3. Visual understanding and sorting""" ]
        p [] [
            Text $"""
            Which one happened earlier: {bo "10/5/12"} or {bo "7/8/12"}? Yeah... first of all, is it mm/dd/yy or dd/mm/yy or something else? For either of them, 
            you will have to think by which of the sections to compare first.
            """
        ]
        p [] [
            Text $"""
            Now, compare {bo "2012-05-10"} and {bo "2012-07-08"}. If you read from left to right, all you need to do is to find the leftmost different digit
            and compare them. Clearly, {bo "2012-07-08"} comes after {bo "2012-05-10"}, because 7 is greater than 5, and you don't need to pad zeros,
            go over the date in a random order of "sections". You do it {bo "exactly"} as you do it with numbers, time, and other measurements.
            """
        ]
        p [] [
            Text $"""
            Sorting of dates usually requires understanding of the date. For example, in computers, you need a separate algorithm which would sort by date.
            What if your files contain date in name, by which you want to sort? It becomes a nightmare to re-arrange them.
            """
        ]
        p [] [
            Text $"""
            Unlike other date formats, sorting this one is the same as sorting alphabetically, because in the alphabet with digits, lower digits come first
            - and that's all you need. Sort by name, and voila, they all sorted.
            """
        ]
        br []
        hr []
        br []
        h2 [] [ Text $"""FAQ / how to""" ]
        p [] [
            h3 [] [ Text $"""What about separator? Does it have to be dash "-"?""" ]
            p [] [ 
                Text $"""
                No, it doesn't, it could be anything (but stay consistent with your choice!). I would prefer dashes because it's ISO8601 and because
                dot "." and slash "/" may have special meaning in different contexts (of course so may have dash "-", but less often to my experience).
                """
            ]
        ]
    ]
}
