export class RegisteredUser {
    
    username: string;
    passwordhash: string;

    constructor(username: string, passwordhash: string) {
        {
          this.username = username;
          this.passwordhash = passwordhash;
        }
    }
  }