import { detailsTemplate } from "./detailsTemplate.js";

let _router = undefined;
let _renderer = undefined;
let _authService = undefined;
let _booksService = undefined;
let _likesService = undefined;

let bookId = undefined;
let userId = undefined;

function initialize(router, renderer, authService, booksService, likesService) {
    _router = router;
    _renderer = renderer;
    _authService = authService;
    _booksService = booksService;
    _likesService = likesService;
}

async function getView(context) {
    bookId = context.params.id;
    let book = await _booksService.getBook(bookId);
    let user = await _authService.getUser();
    let isLoggedIn = user != undefined
    if (isLoggedIn) {
        userId = user._id;
    }
    let isOwner = book._ownerId == userId;
    let buttons = { deleteHandler, likeHandler };
    let likes = await _likesService.getLikes(bookId);
    let hasLiked = await _likesService.hasAlreadyLikedBook(bookId, userId);
    let templateResult = detailsTemplate(book, isOwner, isLoggedIn, buttons, likes, hasLiked);
    _renderer(templateResult);
}

async function deleteHandler() {
    if (confirm("Are you sure you want to delete this book?")) {
        let deleteResult = await _booksService.deleteBook(bookId);
        _router("/dashboard");
    }
}

async function likeHandler() {
    let likeResult = await _likesService.likeBook(bookId);
    _router(`/details/${bookId}`);
}

export default {
    initialize,
    getView
}