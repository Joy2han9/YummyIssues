//对象属性和值深层次相等对比.
function diff(remote, local) {
    const remoteKey = Object.keys(remote);
    const localKey = Object.keys(local);

    if (remoteKey.length !== localKey.length) {
        return false;
    }
    else {
        for (let key in remote) {
            if (!remote.hasOwnProperty(key)) {
                return false;
            }

            if (typeof remote[key] === typeof local[key]) {
                if (typeof remote[key] === 'object' && typeof local[key] === 'object' && remote[key] && local[key]) {
                    const equal = diff(remote[key], local[key]);
                    if (!equal) {
                        return false;
                    }
                }

                if (typeof remote[key] !== 'object' && typeof local[key] !== 'object' && remote[key] !== local[key]) {
                    return false;
                }
            }
            else {
                return false;
            }
        }
    }
    return true;
}

//对象属性和值深层次包含对比，即local的所有属性和值在remote中都能找到，而remote可能有local没有的属性
function contain(remote, local) {
    const remoteKey = Object.keys(remote);
    const localKey = Object.keys(local);

    if (localKey.length > remoteKey.length) {
        return false;
    }
    else {
        for (let key in local) {
            if (!remote.hasOwnProperty(key)) {
                return false;
            }

            if (typeof remote[key] === typeof local[key]) {
                if (typeof remote[key] === 'object' && typeof local[key] === 'object' && remote[key] && local[key]) {
                    const equal = contain(remote[key], local[key]);
                    if (!equal) {
                        return false;
                    }
                }

                if (typeof remote[key] !== 'object' && typeof local[key] !== 'object' && remote[key] !== local[key]) {
                    return false;
                }
            }
            else {
                return false;
            }
        }
    }
    return true;
}