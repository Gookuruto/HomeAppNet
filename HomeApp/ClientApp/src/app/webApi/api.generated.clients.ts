/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.8.2.0 (NJsonSchema v10.2.1.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

import * as moment from 'moment';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

@Injectable()
export class RecipesClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    get(page: number, itemsPerPage: number, sortPropertyName: string | null | undefined, descending: boolean | undefined, search: string | null | undefined): Observable<Recipe[]> {
        let url_ = this.baseUrl + "/api/recipes?";
        if (page === undefined || page === null)
            throw new Error("The parameter 'page' must be defined and cannot be null.");
        else
            url_ += "page=" + encodeURIComponent("" + page) + "&";
        if (itemsPerPage === undefined || itemsPerPage === null)
            throw new Error("The parameter 'itemsPerPage' must be defined and cannot be null.");
        else
            url_ += "itemsPerPage=" + encodeURIComponent("" + itemsPerPage) + "&";
        if (sortPropertyName !== undefined && sortPropertyName !== null)
            url_ += "sortPropertyName=" + encodeURIComponent("" + sortPropertyName) + "&";
        if (descending === null)
            throw new Error("The parameter 'descending' cannot be null.");
        else if (descending !== undefined)
            url_ += "descending=" + encodeURIComponent("" + descending) + "&";
        if (search !== undefined && search !== null)
            url_ += "search=" + encodeURIComponent("" + search) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGet(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGet(<any>response_);
                } catch (e) {
                    return <Observable<Recipe[]>><any>_observableThrow(e);
                }
            } else
                return <Observable<Recipe[]>><any>_observableThrow(response_);
        }));
    }

    protected processGet(response: HttpResponseBase): Observable<Recipe[]> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(Recipe.fromJS(item));
            }
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<Recipe[]>(<any>null);
    }

    addNewRecipe(value: AddRecipeRequest): Observable<FileResponse | null> {
        let url_ = this.baseUrl + "/api/recipes";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(value);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/json"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processAddNewRecipe(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processAddNewRecipe(<any>response_);
                } catch (e) {
                    return <Observable<FileResponse | null>><any>_observableThrow(e);
                }
            } else
                return <Observable<FileResponse | null>><any>_observableThrow(response_);
        }));
    }

    protected processAddNewRecipe(response: HttpResponseBase): Observable<FileResponse | null> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            const fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
            const fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            return _observableOf({ fileName: fileName, data: <any>responseBlob, status: status, headers: _headers });
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<FileResponse | null>(<any>null);
    }

    getRecipeById(id: number): Observable<string | null> {
        let url_ = this.baseUrl + "/api/recipes/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetRecipeById(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetRecipeById(<any>response_);
                } catch (e) {
                    return <Observable<string | null>><any>_observableThrow(e);
                }
            } else
                return <Observable<string | null>><any>_observableThrow(response_);
        }));
    }

    protected processGetRecipeById(response: HttpResponseBase): Observable<string | null> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 !== undefined ? resultData200 : <any>null;
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<string | null>(<any>null);
    }
}

@Injectable()
export class UsersClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    authenticate(model: AuthentiateRequest): Observable<AuthenticateResponse> {
        let url_ = this.baseUrl + "/api/authenticate";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(model);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/json"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processAuthenticate(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processAuthenticate(<any>response_);
                } catch (e) {
                    return <Observable<AuthenticateResponse>><any>_observableThrow(e);
                }
            } else
                return <Observable<AuthenticateResponse>><any>_observableThrow(response_);
        }));
    }

    protected processAuthenticate(response: HttpResponseBase): Observable<AuthenticateResponse> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = AuthenticateResponse.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<AuthenticateResponse>(<any>null);
    }

    getAll(): Observable<FileResponse | null> {
        let url_ = this.baseUrl + "/api/users";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetAll(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetAll(<any>response_);
                } catch (e) {
                    return <Observable<FileResponse | null>><any>_observableThrow(e);
                }
            } else
                return <Observable<FileResponse | null>><any>_observableThrow(response_);
        }));
    }

    protected processGetAll(response: HttpResponseBase): Observable<FileResponse | null> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            const fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
            const fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            return _observableOf({ fileName: fileName, data: <any>responseBlob, status: status, headers: _headers });
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<FileResponse | null>(<any>null);
    }
}

export class Recipe implements IRecipe {
    recipeId!: number;
    url!: string;
    recipeText!: string;
    recipeMaterials!: string[];

    constructor(data?: IRecipe) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
        if (!data) {
            this.recipeMaterials = [];
        }
    }

    init(_data?: any) {
        if (_data) {
            this.recipeId = _data["RecipeId"];
            this.url = _data["Url"];
            this.recipeText = _data["RecipeText"];
            if (Array.isArray(_data["RecipeMaterials"])) {
                this.recipeMaterials = [] as any;
                for (let item of _data["RecipeMaterials"])
                    this.recipeMaterials!.push(item);
            }
        }
    }

    static fromJS(data: any): Recipe {
        data = typeof data === 'object' ? data : {};
        let result = new Recipe();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["RecipeId"] = this.recipeId;
        data["Url"] = this.url;
        data["RecipeText"] = this.recipeText;
        if (Array.isArray(this.recipeMaterials)) {
            data["RecipeMaterials"] = [];
            for (let item of this.recipeMaterials)
                data["RecipeMaterials"].push(item);
        }
        return data; 
    }
}

export interface IRecipe {
    recipeId: number;
    url: string;
    recipeText: string;
    recipeMaterials: string[];
}

export class AddRecipeRequest implements IAddRecipeRequest {
    url!: string;
    recipeText!: string;
    recipeMaterials!: string[];

    constructor(data?: IAddRecipeRequest) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
        if (!data) {
            this.recipeMaterials = [];
        }
    }

    init(_data?: any) {
        if (_data) {
            this.url = _data["Url"];
            this.recipeText = _data["RecipeText"];
            if (Array.isArray(_data["RecipeMaterials"])) {
                this.recipeMaterials = [] as any;
                for (let item of _data["RecipeMaterials"])
                    this.recipeMaterials!.push(item);
            }
        }
    }

    static fromJS(data: any): AddRecipeRequest {
        data = typeof data === 'object' ? data : {};
        let result = new AddRecipeRequest();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["Url"] = this.url;
        data["RecipeText"] = this.recipeText;
        if (Array.isArray(this.recipeMaterials)) {
            data["RecipeMaterials"] = [];
            for (let item of this.recipeMaterials)
                data["RecipeMaterials"].push(item);
        }
        return data; 
    }
}

export interface IAddRecipeRequest {
    url: string;
    recipeText: string;
    recipeMaterials: string[];
}

export class AuthenticateResponse implements IAuthenticateResponse {
    id!: number;
    firstName!: string;
    lastName!: string;
    username!: string;
    token!: string;

    constructor(data?: IAuthenticateResponse) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["Id"];
            this.firstName = _data["FirstName"];
            this.lastName = _data["LastName"];
            this.username = _data["Username"];
            this.token = _data["Token"];
        }
    }

    static fromJS(data: any): AuthenticateResponse {
        data = typeof data === 'object' ? data : {};
        let result = new AuthenticateResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["Id"] = this.id;
        data["FirstName"] = this.firstName;
        data["LastName"] = this.lastName;
        data["Username"] = this.username;
        data["Token"] = this.token;
        return data; 
    }
}

export interface IAuthenticateResponse {
    id: number;
    firstName: string;
    lastName: string;
    username: string;
    token: string;
}

export class AuthentiateRequest implements IAuthentiateRequest {
    username!: string;
    password!: string;

    constructor(data?: IAuthentiateRequest) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.username = _data["Username"];
            this.password = _data["Password"];
        }
    }

    static fromJS(data: any): AuthentiateRequest {
        data = typeof data === 'object' ? data : {};
        let result = new AuthentiateRequest();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["Username"] = this.username;
        data["Password"] = this.password;
        return data; 
    }
}

export interface IAuthentiateRequest {
    username: string;
    password: string;
}

export interface FileResponse {
    data: Blob;
    status: number;
    fileName?: string;
    headers?: { [name: string]: any };
}

export class ApiException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new ApiException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader();
            reader.onload = event => {
                observer.next((<any>event.target).result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}