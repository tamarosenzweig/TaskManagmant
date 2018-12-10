import { environment } from '../../environments/environment';

export class Global {
    //base endpoint for user management RESTful APIs
    public static HOST: string = `${environment.host}/api`;
    public static UERS_PROFILES: string = `${environment.host}/Images/UsersProfiles`;
    public static USER: string = 'user';
    public static STATUS:string='status';
}