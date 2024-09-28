import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

  constructor(private httpClient: HttpClient, @Inject("baseUrl") private baseurl : string) 
  { }
  private url(requestParametr:Partial<RequestParameters>) : String{
    return `${requestParametr.baseUrl ? requestParametr.baseUrl : this.baseurl}/${requestParametr.controller}${requestParametr.action ? `/${requestParametr.action}` : ""}`;
  }
  get<T> (requestParametr:Partial<RequestParameters>, id? : string) : Observable<T>{
    let url : string = "";
    if(requestParametr.fullEndPoint){
      url = requestParametr.fullEndPoint;
    }
    else{
      url = `${this.url(requestParametr)}${id ? `/${id}` : ""}${requestParametr.queryString? `?${requestParametr.queryString}` : ""}`;
    }
    return this.httpClient.get<T>(url,{headers:requestParametr.headers});
  }

  post<T>(requestParametr:Partial<RequestParameters>,body:Partial<T>) : Observable<T>{
    let url : string = "";
    if(requestParametr.fullEndPoint){
      url = requestParametr.fullEndPoint;
    }
    else{
      url = `${this.url(requestParametr)}${requestParametr.queryString? `?${requestParametr.queryString}` : ""}`;
    }
    return this.httpClient.post<T>(url,body,{headers:requestParametr.headers});
  }

  put<T>(requestParametr:Partial<RequestParameters>,body : Partial<T>) : Observable<T>{
    let url : string = "";
    if(requestParametr.fullEndPoint){
      url = requestParametr.fullEndPoint;
    }
    else{
      url = `${this.url(requestParametr)}${requestParametr.queryString? `?${requestParametr.queryString}` : ""}`;
    }
    return this.httpClient.put<T>(url,body,{headers:requestParametr.headers});
  }

  delete<T>(requestParametr:Partial<RequestParameters>,id : string) : Observable<T>{
    let url : string = "";
    if(requestParametr.fullEndPoint){
      url = requestParametr.fullEndPoint;
    }
    else{
      url = `${this.url(requestParametr)}/${id}${requestParametr.queryString? `?${requestParametr.queryString}` : ""}`
    }
    return this.httpClient.delete<T>(url,{headers:requestParametr.headers});
  }
}
export class RequestParameters{
  controller?:string;
  action?:string;
  headers?:HttpHeaders;
  queryString?:string;
  baseUrl?:string; // proqramin basqa bir baseurline istek gonderile biler
  fullEndPoint?:string;
}