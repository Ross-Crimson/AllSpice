import { Profile } from "./Profile.js"

export class Recipe {
    constructor(data) {
        this.id = data.id
        this.title = data.title
        this.instructions = data.instructions
        this.img = data.img
        this.category = data.category
        this.creator = new Profile(data.creator)
    }
}