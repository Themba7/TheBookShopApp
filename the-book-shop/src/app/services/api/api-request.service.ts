import { Injectable } from '@angular/core';
import axios from 'axios';
import { AssetSubscription } from 'src/app/models/asset-subscription';
import { BookShopAsset } from 'src/app/models/book-shop-asset';
import { PatronSignIn } from 'src/app/models/patron-sign-in';
import { PatronSignUp } from 'src/app/models/patron-sign-up';
import { IServiceResponse } from 'src/app/models/service-response';
import { SignInResponse } from 'src/app/models/sign-in-response';
import { SignUpResponse } from 'src/app/models/sign-up-response';
//import * as nProgress from 'nprogress';

const BASE_URL = 'https://localhost:44341/api';
const HEADER = { 'Content-Type': 'application/json' };
const CONFIG = {
  headers: { 'Authorization': `Bearer ${localStorage.getItem('token')}`, 'Content-Type': 'application/json' }
};

////implement interceptor if you still have time
// const apiClient = axios.create({
//   baseURL: 'https://localhost:44341/api',
//   headers: { 'Authorization': `Bearer ${localStorage.getItem('token')}`, 'Content-Type': 'application/json' }
// });
// apiClient.interceptors.request.use(config => {
//   nProgress.start()
//   return config;
// });
// apiClient.interceptors.response.use(response => {
//   nProgress.done();
//   return response;
// });

@Injectable({
  providedIn: 'root'
})
export class ApiRequestService {

  constructor() { }

  public async signUp(patron: PatronSignUp): Promise<IServiceResponse<SignUpResponse>> {
    let result = await axios.post(`${BASE_URL}/account/signup`, patron, { headers: HEADER });
    return result.data;
  }

  public async signIn(patron: PatronSignIn): Promise<IServiceResponse<SignInResponse>> {
    let result = await axios.post(`${BASE_URL}/account/signin`, patron, { headers: HEADER });
    return result.data;
  }

  public async getCatalog() : Promise<IServiceResponse<Array<BookShopAsset>>> {
    let result = await axios.get(`${BASE_URL}/catalog/getcatalog`, { headers: HEADER });
    return result.data;
  }

  public async getAssetById(id: number) : Promise<IServiceResponse<BookShopAsset>> {
    let result = await axios.get(`${BASE_URL}/catalog/getassetbyid/${id}`, CONFIG);
    return result.data;
  }

  public async subscribe(subscription: AssetSubscription) : Promise<IServiceResponse<AssetSubscription>> {
    debugger;
    let result = await axios.post(`${BASE_URL}/subscription/subscribe`, subscription, CONFIG);
    return result.data;
  }

  public async unsubscribe(subscription: AssetSubscription) : Promise<IServiceResponse<AssetSubscription>> {
    let result = await axios.post(`${BASE_URL}/subscription/unsubscribe`, subscription, CONFIG);
    return result.data;
  }


}
