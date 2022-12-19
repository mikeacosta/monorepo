package net.postcore.apilist.cli.service;

import java.util.List;

public record ParentRecord(int count, List<PublicApi> entries) {
}
