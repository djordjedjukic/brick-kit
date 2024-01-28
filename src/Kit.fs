module Kit

open Data

    [<RequireQualifiedAccess>]    
    module Themes =
        let byName (name: string) =
            themes
            |> Seq.filter (fun part -> part.Name = name)
            |> Seq.toList



    
       