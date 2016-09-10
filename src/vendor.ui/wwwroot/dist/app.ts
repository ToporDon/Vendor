import {Component} from "angular2/core"

@Component({
    selector: `app`,
    template: `<div>Hello from </div>`
})

export class App {
    getCompiler() {
        return "Hello world";
    }
}