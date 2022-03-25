import { ServiceResult } from './service-result';

export class TServiceResult<T> extends ServiceResult {
    constructor(
        retVal: T,
        message: string,
        error: any,
        hasError: boolean,
        refrenceId: string,
    ) {
        super(message, error, hasError, refrenceId)
        this.result = retVal;
    }

    result: T;
}
