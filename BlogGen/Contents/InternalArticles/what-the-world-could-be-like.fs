module InternalArticles.WhatTheWorldCouldBeLike

open Giraffe.ViewEngine
open InternalArticleDef

let page = {
    title = "What the world could be like";
    contents = [
        p [] [
            Text " ... if we didn't have social bias. But first, what <i>is</i> bias?"
        ]
        p [] [
            Text "
            By social bias I mean prejudice to people due to their social factors: gender, nationality, ethnicity, age, race, orientation.
            Unfortunately, people are still very biased to others based on indirect factors. For example, girls are taught that IT is for boys.
            Or that Jews are better at finances than others. So, coming from medieval ages, people attribute some properties or characteristics
            to the whole group, and then assume the presence of those characteristics for each individual member of that group.
            "
        ]
        br []
        hr []
        br []
        p [] [
            Text "
            Progressive countries, companies, groups, parties are already combating this bias by imposing quotas on people of gender, orientation,
            and more. It is, of course, on its own a bias, called to countermeasure the existing one. Is it good or bad? I don't know.
            "
        ]
        p [] [
            Text "
            But what if, instead of struggling with the bias by counterattacking it, we could remove the <i>reasons</i> to have a bias? The reason
            for this bias is primarily people's worldview. So we may just teach/educate people on what's good or what's bad. However, what I suggest,
            is abandoning those social borders!
            "
        ]
        p [] [
            Text "
            <b>No</b> gender, nationality, ethnicity, race, orientation. I believe that there's no fundamental difference between people. I'm sure,
            that we could live in society without inheritant differences. Sure we will preserve the psychological differences between biological
            males and females, but it won't matter in the future, rather perceived as some \"feature\" of a person, just like today we see that
            people differ by hair color.
            "
        ]
    ]
}
