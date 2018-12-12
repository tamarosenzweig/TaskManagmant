import { environment } from '../../environments/environment';
import { User } from '../imports';

export class Global {
    //base endpoint for user management RESTful APIs
    //for c#
    public static HOST: string = `${environment.host}/api`;
    public static UERS_PROFILES: string = `${environment.host}/Images/UsersProfiles`;

    //for php
    // public static HOST: string = `${environment.host}/index.php`;
    // public static UERS_PROFILES: string = `${environment.host}/images/users-profiles`;

    public static CURRENT_USER_ID: string = 'currentUserId';
    public static STATUS: string = 'status';
    public static CURRENT_USER: User;

}