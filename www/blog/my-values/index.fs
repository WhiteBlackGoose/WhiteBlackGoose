module www.blog.my_values.index

open Giraffe.ViewEngine
open Page
open PageWrap

let html = wrap www.``static``.styles.css {
    title = "My values"
    url = "blog/my-values"
    filename = "index.html"
    contents = [
        p [] [
            Text "
            Hi. I'm WhiteBlackGoose, and here is what I think is right and wrong. These values are what possible in today's world.
            "
        ]
        br []
        hr []
        br []
        p [] [
            h2 [] [ Text "I'm pro..." ]
            ul [] [
                li [] [ Text "Individualism" ]
                li [] [ Text "Right for gender self-identification. Your gender does not limited you at anything - thus you're free to choose." ]
                li [] [ Text "Right for nationality self-identification. Nobody is born \"Swedish\" (or any other nationality) - you can only become one, by learning its culture and agreeing with its values." ]
                li [] [ Text "Right for culture self-identification. You don't have to be born in a cultural environment to be part of it." ]
                li [] [ Text "Right for self-expression. Nobody is a \"weirdo\"." ]
                li [] [ Text "Expansion of definition of marriage to any two adults, regardless of their self-identities." ]
                li [] [ Text "Free migration. Give everyone a chance to live a good life." ]
                li [] [ Text "Free movement. You can move work/study/live to another city or country without barriers." ]
                li [] [ Text "Free speech. Everyone has a right to be heard, unless the message contradicts previous points or human rights." ]
            ]
        ]
        p [] [
            h2 [] [ Text "I'm against..." ]
            ul [] [
                li [] [ Text "Abuse of free speech. Free speech is when everyone has a right to contribute to the society. Any xenophobia does not contribute to it" ]
                li [] [ Text "Aggressive war, regardless of anything. All conflicts must be solved by the World together." ]
                li [] [ Text "Militarisation. Countries should be defended by common unions without overwhelming military-wise neighbors." ]
                li [] [ Text "Any kinds of xenophobia. Even if majority of a social group thinks one way - you cannot attribute this opinion to every member of this social group" ]
                li [] [ Text "Collective guilt. You have no right to blame someone for not opposing their social group, if they didn't choose it" ]
            ]
        ]
        br []
        hr []
        br []
        p [ _style "text-align: right;" ] [
            Text "
            These values are, however, limited by today's world. In fact, my ideals stretch far beyond these values. 
            "
        ]
    ]
}
