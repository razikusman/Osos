export class Book {
    bookId: Number | undefined
    name: string = ""
    author: Author | undefined
    description: string = ""
    isActive: boolean | undefined
}

export class Author{
    authorId: Number | undefined
    name: string | undefined
    books : any
}
