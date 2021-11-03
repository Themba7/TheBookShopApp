import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AssetSubscription } from '../models/asset-subscription';
import { BookShopAsset } from '../models/book-shop-asset';
import { SubscriptionStatus } from '../models/subscription-status';
import { User } from '../models/user';
import { ApiRequestService } from '../services/api/api-request.service';
import { DialogService } from '../services/dialog/dialog.service';
import { UserManagerService } from '../services/user-manager/user-manager.service';

@Component({
  selector: 'app-subscription',
  templateUrl: './subscription.component.html',
  styleUrls: ['./subscription.component.scss']
})
export class SubscriptionComponent implements OnInit {

  constructor(private route: ActivatedRoute, 
    private apiRequestService: ApiRequestService,
    private dialogService: DialogService,
    private userManagerService: UserManagerService) { }

  id: string | null = "";
  book: BookShopAsset = {} as BookShopAsset;
  user: User = this.userManagerService.userValue;
  subscription: AssetSubscription = new AssetSubscription();

  async ngOnInit(): Promise<void> {
    this.id = this.route.snapshot.paramMap.get('id');

    let result = await this.apiRequestService.getAssetById(+this.id!);
    
    if (result.IsSuccess) {
      this.book = result.Data;
    }
  }

  async subscribe(): Promise<void> {
    debugger;
    this.subscription.Fee = this.book.Cost;
    this.subscription.Status = SubscriptionStatus.Subscribed;
    this.subscription.BookShopAssetId = +this.id!;
    this.subscription.ApplicationUserId = this.user.Id;

    let result = await this.apiRequestService.subscribe(this.subscription);

    if (result.IsSuccess) {
      let message = `You have subscribed to this book for, ZAR ${this.book.Cost} P/M.
      \nYou can cancel your subscription any time.`

      this.dialogService.openDialog(message, 'Subscription');
    }
  }
}
