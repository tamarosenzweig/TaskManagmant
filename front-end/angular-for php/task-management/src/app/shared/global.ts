import { environment } from '../../environments/environment';

export class Global {
    //base endpoint for user management RESTful APIs
    public static HOST: string = environment.host;
    public static PHP_HOST: string = `${environment.phpHost}/index.php`;
    public static BASE_ENDPOINT: string = `${Global.HOST}/api`;
    public static UERS_PROFILES:string=`${environment.phpHost}/images/users-profiles`;
    public static USER: string = 'user';
    public static STATUS:string='status';
}