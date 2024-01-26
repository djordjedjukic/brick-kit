module Model

type Set = {
    Number: string
    Name: string
    Year: int
    ThemeId: int
    NumberOfParts: int
}

type MiniFig = {
    Number: string
    Name: string
    NumberOfParts: int
}

type Color = {
    Name: string
    RGB: string
}

type Part = {
    Category: string
    Number: string
    Name: string
    Color: Color
}

type Inventory = {    
    Parts: Part list
    Quantity: int
    IsSpare: bool    
}
