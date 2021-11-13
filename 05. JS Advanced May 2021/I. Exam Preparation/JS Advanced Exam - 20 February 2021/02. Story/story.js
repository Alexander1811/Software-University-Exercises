class Story {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length == 0) {
            return `${this.title} has 0 likes`;
        }
        else if (this._likes.length == 1) {
            let username = this._likes[0];
            return `${username} likes this story!`;
        }

        let username = this._likes[0];
        return `${username} and ${this._likes.length - 1} others like this story!`;
    }

    like(username) {
        if (this._likes.includes(username)) {
            throw new Error("You can't like the same story twice!");
        }
        if (username == this.creator) {
            throw new Error("You can't like your own story!");
        }
        this._likes.push(username);

        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        if (!this._likes.includes(username)) {
            throw new Error("You can't dislike this story!");
        }
        let likeIndex = this._likes.indexOf(username);
        this._likes.splice(likeIndex, 1);

        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        if (id == undefined || !this._comments.some(c => c.commentId == id)) {
            let commentId = this._comments.length + 1;
            let comment = {
                commentId: commentId,
                username: username,
                content: content,
                replies: []
            };

            this._comments.push(comment);

            return `${username} commented on ${this.title}`;
        }
        else if (this._comments.find(c => c.commentId == id)) {
            let commentId = this._comments[id - 1].commentId;
            let replyId = this._comments[commentId - 1].replies.length + 1;
            let reply = {
                replyId: Number(`${commentId}.${replyId}`),
                username: username,
                content: content
            };

            this._comments[commentId - 1].replies.push(reply);

            return "You replied successfully";
        }
    }

    toString(sortingType) {
        let result = [];
        result.push(`Title: ${this.title}`);
        result.push(`Creator: ${this.creator}`);
        result.push(`Likes: ${this._likes.length}`);
        result.push(`Comments:`);

        let commentsArray = [];
        for (let i = 0; i < this._comments.length; i++) {
            let comment = this._comments[i];
            let repliesArray = comment.replies;
            if (repliesArray.length != 0) {
                repliesArray.sort((a, b) => compareFunction(a, b, sortingType, "reply"));
            }
            commentsArray.push(comment);
        }
        commentsArray.sort((a, b) => compareFunction(a, b, sortingType, "comment"));

        for (let i = 0; i < commentsArray.length; i++) {
            let comment = commentsArray[i];
            result.push(`-- ${comment.commentId}. ${comment.username}: ${comment.content}`);

            if (comment.replies.length != 0) {
                for (let i = 0; i < comment.replies.length; i++) {
                    let reply = comment.replies[i];
                    result.push(`--- ${reply.replyId}. ${reply.username}: ${reply.content}`);
                }
            }
        }

        return result.join('\n');

        function compareFunction(a, b, sortingType, arrayType) {
            if (sortingType == "asc") {
                if (arrayType == "comment") {
                    return a.commentId - b.commentId;
                }
                else if (arrayType == "reply") {
                    return a.replyId - b.replyId;
                }
            }
            else if (sortingType == "desc") {
                if (arrayType == "comment") {
                    return b.commentId - a.commentId;
                }
                else if (arrayType == "reply") {
                    return b.replyId - a.replyId;
                }
            }
            else if (sortingType == "username") {
                return a.username.localeCompare(b.username);
            }
        }
    }
}