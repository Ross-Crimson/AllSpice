export class Recipe {
    constructor(data) {
        this.title = data.title
        this.instructions = data.instructions
        this.img = data.img
        this.category = data.category
        this.creator = data.creator
    }
}