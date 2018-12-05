import { environment } from '../../environments/environment';

export class Global {
    //base endpoint for user management RESTful APIs
    public static HOST: string = environment.host;
    public static PHP_HOST: string = `${environment.phpHost}`;
    public static BASE_ENDPOINT: string = `${Global.HOST}/api`;
    public static UPLOADS:string=`${Global.HOST}/Images`;
    public static USER: string = 'user';
    public static STATUS:string='status';
}