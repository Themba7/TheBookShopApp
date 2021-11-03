import { SubscriptionStatus } from "./subscription-status";

export class AssetSubscription {
    Id: number | undefined;
    Fee: number | undefined;
    Status: SubscriptionStatus | undefined;
    SubscriptionRefId: number | undefined;
    BookShopAssetId: number | undefined;
    ApplicationUserId: string | undefined;
}
