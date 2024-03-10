module Kit

open BrickData

    [<RequireQualifiedAccess>]
    module Themes =        
        let findById  (themeId: int) =
            themes |> Seq.tryFind (fun theme -> theme.Id = themeId)
            
        let findByName (themeName: string) =
            themes |> Seq.tryFind (fun theme -> theme.Name = themeName)

    [<RequireQualifiedAccess>]
    module Sets =       
        let findByNumber (setNumber: string) =
            sets |> Seq.tryFind (fun set -> set.Number = setNumber)
            
        let findByName (setName: string) =
            sets |> Seq.tryFind (fun set -> set.Name = setName)
            
        let findByYear (year: int) =
            sets |> Seq.filter (fun set -> set.Year = year)
            
        let findByYears (years: int list) =
            sets |> Seq.filter (fun set -> List.contains set.Year years)
            
        let findByThemeId (themeId: int) =
            sets |> Seq.filter (fun set -> set.ThemeId = themeId)
            
        let findByThemeName (themeName: string) =
            let theme = Themes.findByName themeName
            sets |> Seq.filter (fun set -> set.ThemeId = theme.Value.Id)
    
    [<RequireQualifiedAccess>]        
    module Parts =
        let findByNumber (partNumber: string) =            
            parts |> Seq.tryFind (fun part -> part.Number = partNumber)
            
        let findAll = parts
        
        let findAllForSet (setNumber: string) =
            let inventory = inventories |> Seq.find (fun i -> i.SetNumber = setNumber)
            inventoryParts |> Seq.filter (fun part -> part.InventoryId = inventory.Id)