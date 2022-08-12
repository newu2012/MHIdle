import { isRef, unref, watchEffect } from "vue";

export interface HttpResponse<T> extends Response {
  parsedBody?: T;
}

export async function useFetch<T>(url: string): Promise<Promise<HttpResponse<T>>> {
  async function doFetch<T>(): Promise<HttpResponse<T>> {
    const response: HttpResponse<T> = await fetch(unref(url));
    response.parsedBody = await response.json();
    return response;
  }

  if (isRef(url)) {
    // setup reactive re-fetch if input URL is a ref
    watchEffect(doFetch);
    return await doFetch<T>();
  } else {
    // otherwise, just fetch once
    // and avoid the overhead of a watcher
    return await doFetch<T>();
  }
}