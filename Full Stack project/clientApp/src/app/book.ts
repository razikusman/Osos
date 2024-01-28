export class Book {
    bookId: Number | undefined
    name: string | undefined
    author: Author | undefined
    description: string | undefined
    isActive: boolean | undefined
}

export class Author{
    authorId: Number | undefined
    name: string | undefined
    books : any
}
