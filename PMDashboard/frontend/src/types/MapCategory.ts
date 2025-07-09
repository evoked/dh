export const mapCategoryFromNumber = (x: number) => {
    switch(x) {
        case 0: 
            return "Default"
        case 1:
            return "Food"
        case 2: 
            return "Electronics"
        case 3:
            return "Clothing"
        case 4: 
            return "Health"
        default:
            return "Default"
    }
}

export const mapCategoryFromString = (x: string) => {
    switch(x) {
        case "Default": 
            return 0
        case "Food":
            return 1
        case "Electronics": 
            return 2
        case "Clothing":
            return 3
        case "Health": 
            return 4
        default: 
            return 0;
    }
}