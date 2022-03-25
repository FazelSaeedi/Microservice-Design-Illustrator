import { Injectable, PLATFORM_ID, Inject } from "@angular/core";
import { DOCUMENT, isPlatformBrowser } from "@angular/common";

@Injectable(
    {
        providedIn: `root`
    }
)
export class LocalRepository {
    private isInBrowser: boolean;
    private isLocalStorageSupported: boolean;
    private isLocalSessionSupported: boolean;
    /**
     * Provided By MH
     */
    constructor(
        @Inject(PLATFORM_ID) private platformId,
        @Inject(DOCUMENT) private doc: Document
    ) {
        this.isInBrowser = isPlatformBrowser(this.platformId);
        this.isLocalStorageSupported = typeof (localStorage) !== "undefined";
        this.isLocalSessionSupported = typeof (sessionStorage) !== "undefined";
    }


    public get IsInBrowser(): boolean {
        return this.isInBrowser;
    }



    public get getWindow(): Window | any {
        return this.doc.defaultView;
    }

    // public get getDocument() :Document {
    //     return this.doc;
    // }





    // /**
    //  * stores data into localStorage by taking care of SSR
    //  * @param key for reference to date
    //  * @param value data to be stored
    //  */
    public setItem(key: string, value: string) {
        if (this.isInBrowser && this.isLocalStorageSupported)
            localStorage.setItem(key, value);
    }

    public setItemAs<T>(key: string, value: T) {
        if (this.isInBrowser && this.isLocalStorageSupported) {
            const data = JSON.stringify(value);
            localStorage.setItem(key, data);
        }
    }


    // /**
    //  * stores data into sessionStorage by taking care of SSR
    //  * @param key for reference to date
    //  * @param value data to be stored
    //  */
    public setItemSession(key: string, value: string) {
        if (this.isInBrowser && this.isLocalSessionSupported)
            sessionStorage.setItem(key, value);
    }

    // /**
    //  * get data from localStorage by taking care of SSR
    //  * @param key for reference key to retrive value
    //  */
    public getItem(key: string): string | undefined {
        if (this.isInBrowser && this.isLocalStorageSupported) {
            return localStorage.getItem(key) || undefined
        }
        return undefined;
    }

    public getItemAs<T>(key: string): T | undefined {
        let data: T;
        if (this.isInBrowser && this.isLocalStorageSupported) {
            const foundItem = localStorage.getItem(key) || '';
            data = JSON.parse(foundItem) as T;
            return data
        }
        return undefined;
    }

    // /**
    // * get data from sessionStorage by taking care of SSR
    // * @param key for reference key to retrive value
    // */
    // public getItemSession(key: string): string {
    //     return (this.isInBrowser && this.isLocalSessionSupported)
    //         ? sessionStorage.getItem(key)
    //         : null;
    // }

    // /**
    //  * Clear local Storage
    //  */
    public clear() {
        if (this.isInBrowser && this.isLocalStorageSupported)
            localStorage.clear();
    }

    // /**
    //  * clear session storage
    //  */
    public clearSession() {
        if (this.isInBrowser && this.isLocalSessionSupported)
            sessionStorage.clear();
    }


    // /**
    //  * remove local Storage
    //  * @param key for reference key to remove value
    //  */
    public remove(key: string) {
        if (this.isInBrowser && this.isLocalStorageSupported)
            localStorage.removeItem(key);
    }
    // /**
    //  * remove from Session Storage
    //  * @param key for reference key to remove value
    //  */
    public removeSession(key: string) {
        if (this.isInBrowser && this.isLocalSessionSupported)
            sessionStorage.removeItem(key);
    }
}